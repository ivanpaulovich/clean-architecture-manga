import http from "./http-common"

const getAccounts = (user) => {
  return http
    .createAxios(user)
    .get("/api/v1/accounts");
};

const getAccount = (user, id) => {
  return http
    .createAxios(user)
    .get(`/api/v1/accounts/${id}`);
};

const openAccount = (user, data) => {
  return http
    .createAxios(user)
    .post("/api/v1/accounts", data);
};

const closeAccount = (user, id) => {
  return http
    .createAxios(user)
    .delete(`/api/v1/accounts/${id}`);
};

export default {
  getAccounts,
  getAccount,
  openAccount,
  closeAccount
};