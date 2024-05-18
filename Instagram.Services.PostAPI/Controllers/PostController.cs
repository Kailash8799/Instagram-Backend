using Asp.Versioning;
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
        public PostController(IPostService postService) {
            _postService = postService;
        }

        [ApiVersion("1.0")]
        [HttpGet("get/{userId}", Name = "GetPostByUserID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPostByUserID(string userId) {
            try {
                var res = ApiResponseHelper.CreateResponse(500, "Internal server error", false, "");
                return Ok(res);
            } catch (Exception) {
                var res = ApiResponseHelper.CreateResponse(500, "Internal server error", false, "");
                return StatusCode(500, res);
            }
        }

        [ApiVersion("1.0")]
        [HttpGet("get/post-details/{postId}", Name = "GetPostByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPostByID(string postId) {
            try {
                var res = ApiResponseHelper.CreateResponse(500, "Internal server error", false, "");
                return Ok(res);
            } catch (Exception) {
                var res = ApiResponseHelper.CreateResponse(500, "Internal server error", false, "");
                return StatusCode(500, res);
            }
        }

        [ApiVersion("1.0")]
        [HttpPost("create", Name = "CreatePost")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePost([FromBody] PostRequestDTO postDTO) {
            try {
                string response = await _postService.CreatePost(postDTO);
                if(!(string.IsNullOrEmpty(response))){
                    var result = ApiResponseHelper.CreateResponse(400, response, false, "");
                    return BadRequest(result);
                }
                var successResult = ApiResponseHelper.CreateResponse(201, "Post created successfully", true, "");
                return StatusCode(201, successResult);
            } catch (Exception) {
                var result = ApiResponseHelper.CreateResponse(500, "Internal server error", false, "");
                return StatusCode(500, result);
            }
        }

        [ApiVersion("1.0")]
        [HttpPatch("update/{id}", Name = "UpdatePost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdatePost(string id,JsonPatchDocument<PostRequestDTO> postPatchDTO) {
            try {
                var res = ApiResponseHelper.CreateResponse(500, "Internal server error", false, "");
                return Ok(res);
            } catch (Exception) {
                var res = ApiResponseHelper.CreateResponse(500, "Internal server error", false, "");
                return StatusCode(500, res);
            }
        }

        [ApiVersion("1.0")]
        [HttpDelete("delete/{id}", Name = "DeletePost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePost(string id) {
            try {
                var res = ApiResponseHelper.CreateResponse(500, "Internal server error", false, "");
                return Ok(res);
            } catch(Exception) {
                var res = ApiResponseHelper.CreateResponse(500, "Internal server error", false, "");
                return StatusCode(500, res);
            }
        }
    }
}
