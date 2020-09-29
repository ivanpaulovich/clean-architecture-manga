import http from "http-common";

const deposit = (user, data) => {
  return http
    .createAxios(user)
    .post("/transactions", data);
};

const withdraw = (user, data) => {
  return http
    .createAxios(user)
    .post("/transactions", data);
};

const transfer = (user, data) => {
  return http
    .createAxios(user)
    .post("/transactions", data);
};

export default {
  deposit,
  withdraw,
  transfer
};