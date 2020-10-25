import axios from "axios";

const deposit = (accountId, data) => {
  return axios
    .patch(`/api/v1/transactions/${accountId}/deposit`, data);
};

const withdraw = (accountId, data) => {
  return axios
    .patch(`/api/v1/transactions/${accountId}/withdraw`, data);
};

const transfer = (originAccountId, destinationAccountId, data) => {
  return axios
    .patch(`/api/v1/transactions/${originAccountId}/${destinationAccountId}`, data);
};

export default {
  deposit,
  withdraw,
  transfer
};