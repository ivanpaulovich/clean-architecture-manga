import http from "./http-common"

const deposit = (user, accountId, data) => {
  return http
    .createAxios(user)
    .patch(`/api/v1/transactions/${accountId}/deposit`, data);
};

const withdraw = (user, accountId, data) => {
  return http
    .createAxios(user)
    .patch(`/api/v1/transactions/${accountId}/withdraw`, data);
};

const transfer = (user, originAccountId, destinationAccountId, data) => {
  return http
    .createAxios(user)
    .patch(`/api/v1/transactions/${originAccountId}/${destinationAccountId}`, data);
};

export default {
  deposit,
  withdraw,
  transfer
};