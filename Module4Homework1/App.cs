using Module4Homework1.Contracts;

namespace Module4Homework1
{
    public class App
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IResourceService _resourceService;

        public App(
            IUserService userService,
            IAuthService authService,
            IResourceService resourceService)
        {
            _userService = userService;
            _authService = authService;
            _resourceService = resourceService;
        }

        public async Task Start()
        {

            var registerUser = Task.Run(async () => await _authService.RegisterAsync("ivan@gmail.com", "ivan"));
            var loginUser = Task.Run(async () => await _authService.LoginAsync("ivan@gmail.com", "ivan"));

            var getListOfUsersByPage3 = Task.Run(async () => await _userService.GetListOfUsersByPageAsync(3));
            var getSingleUserById = Task.Run(async () => await _userService.GetSingleUserAsync(2));
            var createUser = Task.Run(async () => await _userService.CreateUserAsync("ivan@gmail.com", "front-end developer"));
            var updateUser = Task.Run(async () => await _userService.UpdateUserAsync(3, "ivan@gmail.com", "back-end developer"));
            var deleteUser = Task.Run(async () => await _userService.DeleteUserAsync(3));

            var getResources = Task.Run(async () => await _resourceService.GetListOfResourcesAsync());
            var getResource = Task.Run(async () => await _resourceService.GetSingleResourceAsync(2));

            await Task.WhenAll(
                registerUser,
                loginUser,
                getListOfUsersByPage3,
                getSingleUserById,
                createUser,
                updateUser,
                deleteUser,
                getResources,
                getResource);

            var getRegisterUserResult = await registerUser;
            var getLoginUserResult = await loginUser;
            var getListOfUsersByPage3Result = await getListOfUsersByPage3;
            var getSingleUserByIdResult = await getSingleUserById;
            var createUserResult = await createUser;
            var updateUserResult = await updateUser;
            var deleteUserResult = await deleteUser;
            var getResourcesResult = await getResources;
            var getResourceResult = await getResource;
        }
    }
}
