import React, { useState } from "react";
import accountsService from "../store/accountsService";

export const OpenAccountUI = (props) => {
  const initialOpenAccountState = {
    id: null,
    amount: "",
    currency: ""
  };
  const [account, setAccount] = useState(initialOpenAccountState);
  const [submitted, setSubmitted] = useState(false);
  const [openAccountUIState] = useState(props);

  const handleInputChange = event => {
    const { name, value } = event.target;
    setAccount({ ...account, [name]: value });
  };

  const saveAccount = () => {
    var bodyFormData = new FormData();
    bodyFormData.append('amount', account.amount);
    bodyFormData.append('currency', account.currency);

    accountsService
      .openAccount(openAccountUIState, bodyFormData)
      .then(response => {
        setAccount({
          id: response.data.account.accountId,
          title: response.data.account.accountId,
          description: response.data.account.accountId
        });
        setSubmitted(true);
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  const newAccount = () => {
    setAccount(initialOpenAccountState);
    setSubmitted(false);
  };

  return (
    <div className="submit-form">
      {submitted ? (
        <div>
          <h4>You submitted successfully!</h4>
          <button className="btn btn-success" onClick={newAccount}>
            Add
          </button>
        </div>
      ) : (
        <div>
          <div className="form-group">
            <label htmlFor="amount">Amount</label>
            <input
              type="text"
              className="form-control"
              id="amount"
              required
              value={account.amount}
              onChange={handleInputChange}
              name="amount"
            />
          </div>

          <div className="form-group">
            <label htmlFor="currency">Currency</label>
            <input
              type="text"
              className="form-control"
              id="currency"
              required
              value={account.currency}
              onChange={handleInputChange}
              name="currency"
            />
          </div>

          <button onClick={saveAccount} className="btn btn-success">
            Submit
          </button>
        </div>
      )}
    </div>
  );
};