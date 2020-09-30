import React, { useState, useEffect } from "react";
import accountsService from "../store/accountsService";
import {
  BrowserRouter as Router,
  Switch,
  Route,
  useParams,
} from "react-router-dom";

export const AccountUI = (props) => {
  const accountState = {
    account: {
      credits: [],
      debits: []
    }
  };
  const [account, setAccount] = useState(accountState);
  const [openAccountUIState] = useState(props);
  let { accountId } = useParams();

  const getAccount = (id) => {
    openAccountUIState.openIdManager.getUser().then((user) => {
      if (user) {
        accountsService
          .getAccount(user, accountId)
          .then((response) => {
            setAccount(response.data.account);
            console.log(response.data);
          })
          .catch((e) => {
            console.log(e);
          });
      } else {
        console.log("not logged in.");
      }
    });
  };

  useEffect(() => {
    getAccount(accountId);
  }, [accountId]);

  return (
    <React.Fragment>
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Account</th>
            <th>Current Balance</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>
              {account.accountId}
            </td>
            <td>{account.currentBalance}</td>
          </tr>
        </tbody>
      </table>

      <table className="table table-striped" aria-labelledby="tabelLabel">
          <thead>
          <tr>
              <th>Transaction ID</th>
              <th>Amount</th>
              <th>Transaction Date</th>
          </tr>
          </thead>
          <tbody>
          {account.credits && account.credits.map((credit) =>
              {
                  return <tr>
                      <td>
                          {credit.transactionId}
                      </td>
                      <td>
                          {credit.amount}
                      </td>
                      <td>{credit.transactionDate}</td>
                  </tr>;
              }
          )}
          </tbody>
      </table>
    </React.Fragment>
  );
};
