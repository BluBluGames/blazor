namespace BluBlu.Tenants.Domain.UsersEntity;

public interface IUsersRepository
{
    Task<User> Create(User user, string schema);
}