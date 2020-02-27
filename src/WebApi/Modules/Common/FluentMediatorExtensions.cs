namespace WebApi.Modules.Common
{
    using Application.Boundaries.CloseAccount;
    using Application.Boundaries.Deposit;
    using Application.Boundaries.GetAccountDetails;
    using Application.Boundaries.GetCustomerDetails;
    using Application.Boundaries.Register;
    using Application.Boundaries.Transfer;
    using Application.Boundaries.Withdraw;
    using FluentMediator;
    using Microsoft.Extensions.DependencyInjection;
    using IUseCase = Application.Boundaries.CloseAccount.IUseCase;

    public static class FluentMediatorExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddFluentMediator(
                builder =>
                {
                    builder.On<CloseAccountInput>().PipelineAsync()
                        .Call<IUseCase>((handler, request) => handler.Execute(request));

                    builder.On<DepositInput>().PipelineAsync()
                        .Call<Application.Boundaries.Deposit.IUseCase>((handler, request) => handler.Execute(request));

                    builder.On<GetAccountDetailsInput>().PipelineAsync()
                        .Call<Application.Boundaries.GetAccountDetails.IUseCase>((handler, request) =>
                            handler.Execute(request));

                    builder.On<GetCustomerDetailsInput>().PipelineAsync()
                        .Call<Application.Boundaries.GetCustomerDetails.IUseCase>((handler, request) =>
                            handler.Execute(request));

                    builder.On<RegisterInput>().PipelineAsync()
                        .Call<Application.Boundaries.Register.IUseCase>((handler, request) => handler.Execute(request));

                    builder.On<TransferInput>().PipelineAsync()
                        .Call<Application.Boundaries.Transfer.IUseCase>((handler, request) => handler.Execute(request));

                    builder.On<WithdrawInput>().PipelineAsync()
                        .Call<Application.Boundaries.Withdraw.IUseCase>((handler, request) => handler.Execute(request));

                    builder.On<GetAccountDetailsInput>().PipelineAsync("GetAccountDetailsV2")
                        .Call<IUseCaseV2>((handler, request) => handler.Execute(request));
                });

            return services;
        }
    }
}
