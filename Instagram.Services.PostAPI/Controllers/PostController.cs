using Asp.Versioning;
using AutoMapper;
using Instagram.Services.PostAPI.Models.Dto;
using Instagram.Services.PostAPI.Service.IService;
using Instagram.Services.PostAPI.Utils;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Services.PostAPI.Controllers {

    [Route("/api/v1/post")]
    [ApiController]
    public class PostController : ControllerBase {
        
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public PostController(IPostService postService,IMapper mapper) {
            _postService = postService;
            _mapper = mapper;
        }

        [ApiVersion("1.0")]
        [HttpGet("get/{userId}", Name = "GetPostByUserID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPostByUserID(string userId) {
            List<PostResponseDTO> userPosts = _postService.GetPostByUserID(userId);
            var res = ApiResponseHelper.CreateResponse(200, "Post", false, userPosts);
            return Ok(res);
        }

        [ApiVersion("1.0")]
        [HttpGet("get/post-details/{postId}", Name = "GetPostByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPostByID(string postId) {
             PostResponseDTO post = _postService.GetPostByID(postId);
             var res = ApiResponseHelper.CreateResponse(200, "Post", false, post);
             return Ok(res);
        }

        [ApiVersion("1.0")]
        [HttpPost("create", Name = "CreatePost")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePost([FromBody] PostRequestDTO postDTO) {
                string response = await _postService.CreatePost(postDTO);
                if(!(string.IsNullOrEmpty(response))){
                    var result = ApiResponseHelper.CreateResponse(400, response, false, "");
                    return BadRequest(result);
                }
                var successResult = ApiResponseHelper.CreateResponse(201, "Post created successfully", true, "");
                return StatusCode(201, successResult);
        }

        [ApiVersion("1.0")]
        [HttpPatch("update/{id}", Name = "UpdatePost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePost(string id,JsonPatchDocument<UpdatePostRequestDTO> postPatchDTO) {
            if (id == null || postPatchDTO == null) {
                throw new BadHttpRequestException("Id or update data not provided", 400);
            }
            PostResponseDTO postDTO = _postService.GetPostByID(id);
            UpdatePostRequestDTO updateDTO = _mapper.Map<UpdatePostRequestDTO>(postDTO);
            postPatchDTO.ApplyTo(updateDTO, ModelState);
            if (!ModelState.IsValid) {
                throw new Exception("Some field are not valid");
            }
            PostResponseDTO res = await _postService.UpdatePost(id, updateDTO);
            var response = ApiResponseHelper.CreateResponse(200, "Post updated successfully", true, res);
            return Ok(response);
        }

        [ApiVersion("1.0")]
        [HttpDelete("delete/{id}", Name = "DeletePost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePost(string id) {
                _postService.DeletePost(id);
                var res = ApiResponseHelper.CreateResponse(200, "Post deleted successfully", true, "");
                return Ok(res);
        }
    }
}
