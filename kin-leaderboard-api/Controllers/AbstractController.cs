using System.Threading.Tasks;
using kin_leaderboard_api.Services.Abstract;
using kin_leaderboard_frontend.Shared.Models.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kin_leaderboard_api.Controllers
{
    public abstract class AbstractController<TService, TModel, TId> : ControllerBase
        where TService : IAppService<TModel, TId> where TModel : class
    {
        protected readonly TService Service;

        protected AbstractController(TService service)
        {
            Service = service;
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<BaseResponseData<TModel>>> Get(TId id)
        {
            return Ok(ToResultReponse(await Service.Get(id).ConfigureAwait(false)));
        }

        [HttpPost]
        [Authorize]
        public virtual async Task<ActionResult<BaseResponseData<ApiResult>>> Post([FromBody] TModel value)
        {
            await Service.Post(value);
            return Ok(ToResultReponse(1));
        }

        [HttpPut("{id}")]
        [Authorize]
        public virtual async Task<ActionResult<BaseResponseData<TModel>>> Put(TId id, [FromBody] TModel value)
        {
            await Service.Put(id, value).ConfigureAwait(false);
            return Ok(ToResultReponse(value));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public virtual async Task<ActionResult<BaseResponseData<ApiResult>>> Delete(TId id)
        {
            int ret = await Service.Delete(id).ConfigureAwait(false);
            return Ok(ToResultReponse(ret));
        }

        protected BaseResponseData<ApiResult> ToResultReponse(int value)
        {
            return new BaseResponseData<ApiResult>(new ApiResult(value > 0));
        }

        protected BaseResponseData<T> ToResultReponse<T>(T value) where T : class
        {
            return new BaseResponseData<T>(value);
        }
    }
}