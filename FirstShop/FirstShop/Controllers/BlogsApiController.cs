using AutoMapper;
using FirstShop.Core.Services.Blogs.Post;
using FirstShop.Core.Services.Blogs.PostComment;
using FirstShop.Core.Services.Blogs.PostTypes;
using FirstShop.Core.Tools;
using FirstShop.Core.ViewModels.Blogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstShop.Controllers
{
    #region Post
    [Route("api/[controller]")]
    [ApiController]
    public class PostApiController : ControllerBase
    {
        private IMapper _mapper;
        private IPostServices _postServices;
        public PostApiController(IMapper mapper, IPostServices postServices)
        {
            _mapper = mapper;
            _postServices = postServices;
        }

        public List<PostViewModel> postViewModel { get; set; }

        [HttpGet]
        public List<PostViewModel> GetuserPosts()
        {
            postViewModel = _postServices.GetAllPosts().ToList();
            return postViewModel;
        }

        [HttpGet("{id}")]
        public ActionResult<PostForApiViewModel> GetPostById(long id)
        {
            var post = _postServices.GetPostsById(id);
            if (post == null)
                return NotFound(post);
            else
                return Ok(post);
        }


        [HttpPost]
        public long AddPostFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddPostFromApiBody")]
        public async Task<long> AddPostFromApiBody(PostForApiViewModel post, IFormFile PostImg)
        {
            var po = _mapper.Map<PostForApiViewModel, PostViewModel>(post);

            string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(PostImg.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await PostImg.CopyToAsync(stream);
            }


            po.PostImage = "/Images/" + fileName;

            return await _postServices.AddPosts(po, PostImg);
        }

        [HttpPost("AddPostFromApiQuery")]
        public async Task<long> AddUserRoleFromApiQuery([FromQuery] PostForApiViewModel post, IFormFile PostImg)
        {
            var po = _mapper.Map<PostForApiViewModel, PostViewModel>(post);

            string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(PostImg.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await PostImg.CopyToAsync(stream);
            }


            po.PostImage = "/Images/" + fileName;

            return await _postServices.AddPosts(po, PostImg);
        }


        [HttpPut("EditPostFromApi")]
        public async Task<IActionResult> EditPostFromApi(PostForApiViewModel post, IFormFile PostImg)
        {
            var po = _mapper.Map<PostForApiViewModel, PostViewModel>(post);

            string fileName = NameGenerator.GenerateUniqCode() + Path.GetExtension(PostImg.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", fileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await PostImg.CopyToAsync(stream);
            }


            po.PostImage = "/Images/" + fileName;

            await _postServices.AddPosts(po, PostImg);

            return Ok();
        }

        [HttpDelete("DeletePostFromApi")]
        public async Task<IActionResult> DeletePostFromApi(long id)
        {
            var ro = _postServices.GetPostsById(id);

            if (ro == null)
            {
                return NotFound(new { message = "Not found !" });
            }

            await _postServices.DeletePosts(id);

            return Ok();
        }
    }
    #endregion

    #region PostType
    [ApiController]
    [Route("api/[controller]")]
    public class PostTypeController : ControllerBase
    {
        private IMapper _mapper;
        private IPostTypeServices _PostTypeServices;
        public PostTypeController(IPostTypeServices PostTypeServices, IMapper mapper)
        {
            _PostTypeServices = PostTypeServices;
            _mapper = mapper;
        }

        public List<PostTypeViewModel> PostTypeList { get; set; }

        [HttpGet]
        public List<PostTypeViewModel> GetPostType()
        {
            PostTypeList = _PostTypeServices.GetAllPostTypes().ToList();
            return PostTypeList;
        }

        [HttpGet("{id}")]
        public ActionResult<PostTypeForApiViewModel> GetPostTypeById(long id)
        {
            var pt = _PostTypeServices.GetPostTypesById(id);
            if (pt == null)
                return NotFound(pt);
            else
                return Ok(pt);
        }


        [HttpPost]
        public long AddPostTypeFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddPostTypeFromApiBody")]
        public async Task<long> AddPostTypeFromApiBody(PostTypeForApiViewModel postType)
        {
            var pt = _mapper.Map<PostTypeForApiViewModel, PostTypeViewModel>(postType);

            return await _PostTypeServices.AddUPostTypes(pt);
        }

        [HttpPost("AddPostTypeFromApiQuery")]
        public async Task<long> AddPostTypeFromApiQuery([FromQuery] PostTypeForApiViewModel postType)
        {
            var pt = _mapper.Map<PostTypeForApiViewModel, PostTypeViewModel>(postType);

            return await _PostTypeServices.AddUPostTypes(pt);
        }


        [HttpPut("EditPostTypeFromApi")]
        public async Task<IActionResult> EditPostTypeFromApi(PostTypeForApiViewModel postType)
        {
            var pt = _mapper.Map<PostTypeForApiViewModel, PostTypeViewModel>(postType);

            _PostTypeServices.EditPostTypes(pt);

            return Ok();
        }

        [HttpDelete("DeletePostTypeFromApi")]
        public async Task<IActionResult> DeletePostTypeFromApi(long id)
        {
            var br = _PostTypeServices.GetPostTypesById(id);

            if (br == null)
            {
                return NotFound(new { message = "Not found !" });
            }

            await _PostTypeServices.DeletePostTypes(id);

            return Ok();
        }

    }
    #endregion

    #region PostComment
    [ApiController]
    [Route("api/[controller]")]
    public class PostCommentController : ControllerBase
    {
        private IMapper _mapper;
        private IPostCommentServices _PostCommentServices;
        public PostCommentController(IPostCommentServices PostCommentServices, IMapper mapper)
        {
            _PostCommentServices = PostCommentServices;
            _mapper = mapper;
        }

        public List<PostCommentViewModel> postCommentList { get; set; }

        [HttpGet]
        public List<PostCommentViewModel> GetPostComments()
        {
            postCommentList = _PostCommentServices.GetAllPostComments().ToList();
            return postCommentList;
        }

        [HttpGet("{id}")]
        public ActionResult<PostCommentForApiViewModel> GetPostCommentById(long id)
        {
            var pc = _PostCommentServices.GetPostCommentssByIdAsync(id);
            if (pc == null)
                return NotFound(pc);
            else
                return Ok(pc);
        }


        [HttpPost]
        public long AddPostCommentFromApi(long id)
        {
            return id;
        }

        [HttpPost("AddPostCommentFromApiBody")]
        public async Task<long> AddPostCommentFromApiBody(PostCommentForApiViewModel postComment)
        {
            var pc = _mapper.Map<PostCommentForApiViewModel, PostCommentViewModel>(postComment);

            return await _PostCommentServices.AddUPostComments(pc);
        }

        [HttpPost("AddPostCommentFromApiQuery")]
        public async Task<long> AddPostCommentFromApiQuery([FromQuery] PostCommentForApiViewModel postComment)
        {
            var pc = _mapper.Map<PostCommentForApiViewModel, PostCommentViewModel>(postComment);

            return await _PostCommentServices.AddUPostComments(pc);
        }


        [HttpPut("EditPostCommentFromApi")]
        public async Task<IActionResult> EditPostCommentFromApi(PostCommentForApiViewModel postComment)
        {
            var pc = _mapper.Map<PostCommentForApiViewModel, PostCommentViewModel>(postComment);

            _PostCommentServices.EditComment(pc);

            return Ok();
        }

        [HttpDelete("DeletePostCommentFromApi")]
        public async Task<IActionResult> DeletePostCommentFromApi(long id)
        {
            var pc = _PostCommentServices.GetPostCommentssByIdAsync(id);

            if (pc == null)
            {
                return NotFound(new { message = "Not found !" });
            }

            await _PostCommentServices.DeletePostComments(id);

            return Ok();
        }


        
    }
    #endregion
}