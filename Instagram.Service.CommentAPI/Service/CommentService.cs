using AutoMapper;
using Instagram.Service.CommentAPI.Service.IService;
using Instagram.Services.CommentAPI.Data;
using Instagram.Services.CommentAPI.Models;
using Instagram.Services.CommentAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Service.CommentAPI.Service
{
    public class CommentService : ICommentService {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommentService(AppDbContext appDbContext,IMapper mapper) {
            _dbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<CommentResponseDTO> AddComment(CommentRequestDTO comment) {
            Comment newcomment = _mapper.Map<Comment>(comment);
            await _dbContext.Comment.AddAsync(newcomment);
            await _dbContext.SaveChangesAsync();
            CommentResponseDTO commentResponseDTO = _mapper.Map<CommentResponseDTO>(newcomment);
            return commentResponseDTO;
        }

        public bool DeleteCommentByCommentId(string commentId) {
            Comment comment = _dbContext.Comment.AsNoTracking().FirstOrDefault(c=>c.Id == new Guid(commentId)) ?? throw new Exception("Comment not found with this id");
            _dbContext.Comment.Remove(comment);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteCommentByPostId(string postId) {
            var commentsToDelete = _dbContext.Comment.AsNoTracking().Where(c => c.PostId == postId);
            _dbContext.Comment.RemoveRange(commentsToDelete);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteCommentByUserId(string userId) {
            var commentsToDelete = _dbContext.Comment.AsNoTracking().Where(c => c.UserId == userId);
            _dbContext.Comment.RemoveRange(commentsToDelete);
            _dbContext.SaveChanges();
            return true;
        }

        public List<CommentResponseDTO> GetCommentByPostId(string postId) {
            var commentsToDelete = _dbContext.Comment.AsNoTracking().Where(c => c.PostId == postId);
            List<CommentResponseDTO> commentsByPost = _mapper.Map<List<CommentResponseDTO>>(commentsToDelete);
            return commentsByPost;
        }

        public List<CommentResponseDTO> GetCommentByUserId(string userId) {
            var commentsToDelete = _dbContext.Comment.AsNoTracking().Where(c => c.UserId == userId);
            List<CommentResponseDTO> commentsByPost = _mapper.Map<List<CommentResponseDTO>>(commentsToDelete);
            return commentsByPost;
        }
    }
}
