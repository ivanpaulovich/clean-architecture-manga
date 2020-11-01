import api from "./oauth"

const deposit = (accountId, data) => {
  return api
    .patch(`/api/v1/transactions/${accountId}/deposit`, data);
};

const withdraw = (accountId, data) => {
  return api
    .patch(`/api/v1/transactions/${accountId}/withdraw`, data);
};

const transfer = (originAccountId, destinationAccountId, data) => {
  return api
    .patch(`/api/v1/transactions/${originAccountId}/${destinationAccountId}`, data);
};

export default {
  deposit,
  withdraw,
  transfer
};