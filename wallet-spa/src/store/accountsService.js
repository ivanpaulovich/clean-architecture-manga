import axios from "axios";

const getAccounts = () => {
  return axios
    .get("/api/v1/accounts");
};

const getAccount = (id) => {
  return axios
    .get(`/api/v1/accounts/${id}`);
};

const openAccount = (data) => {
  return axios
    .post("/api/v1/accounts", data);
};

const closeAccount = (id) => {
  return axios
    .delete(`/api/v1/accounts/${id}`);
};

export default {
  getAccounts,
  getAccount,
  openAccount,
  closeAccount
};