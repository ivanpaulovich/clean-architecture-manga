import api from "./oauth"

const getAccounts = () => {
  return api
    .get("/api/v1/accounts");
};

const getAccount = (id) => {
  return api
    .get(`/api/v1/accounts/${id}`);
};

const openAccount = (data) => {
  return api
    .post("/api/v1/accounts", data);
};

const closeAccount = (id) => {
  return api
    .delete(`/api/v1/accounts/${id}`);
};

export default {
  getAccounts,
  getAccount,
  openAccount,
  closeAccount
};