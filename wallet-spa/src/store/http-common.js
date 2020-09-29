import axios from "axios";

const createAxios = user => {
  return axios.create({
    baseURL: process.env.REACT_APP_ACCOUNTS_API,
    headers: { 
      'Authorization': 'Bearer ' + user.access_token,
      'Content-Type': 'multipart/form-data'
     }
  })
};

export default {
  createAxios
};