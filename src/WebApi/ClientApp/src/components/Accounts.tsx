import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as AccountsStore from '../store/Accounts';
import {Link} from "react-router-dom";
import {NavLink} from "reactstrap";

type AccountsProps =
    AccountsStore.AccountsState
  & typeof AccountsStore.actionCreators;


class Accounts extends React.PureComponent<AccountsProps> {
  public componentDidMount() {
    this.ensureDataFetched();
  }

  public render() {
    return (
      <React.Fragment>
        <h1>Manage Accounts</h1>
        <p>All your checking accounts.</p>

      <table className='table table-striped' aria-labelledby="tabelLabel">
          <thead>
          <tr>
              <th>CustomerID</th>
              <th>Name</th>
              <th>SSN</th>
          </tr>
          </thead>
          <tbody>
              <tr>
                  <td>{this.props.customer.customerId}</td>
                  <td>{this.props.customer.name}</td>
                  <td>{this.props.customer.ssn}</td>
              </tr>
          </tbody>
      </table>
        {this.renderForecastsTable()}
      </React.Fragment>
    );
  }

  private ensureDataFetched() {
    this.props.requestAccounts();
  }

  private renderForecastsTable() {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Account</th>
            <th>Current Balance</th>
          </tr>
        </thead>
        <tbody>
          {this.props.customer.accounts.map((account: AccountsStore.Account) =>
            <tr key={account.accountId}>
              <td><NavLink tag={Link} className="text-dark" to="/transactions/{account.accountId}">Transactions</NavLink> </td>
              <td>{account.currentBalance}</td>
                <td>

                    <table className='table table-striped' aria-labelledby="tabelLabel">
                        <thead>
                        <tr>
                            <th>Transaction</th>
                            <th>Amount</th>
                            <th>Description</th>
                            <th>Transaction Date</th>
                        </tr>
                        </thead>
                        <tbody>
                        {account.transactions.map((transaction: AccountsStore.Transaction) =>
                            <tr key={transaction.transactionId}>
                                <td>{transaction.transactionId}</td>
                                <td>{transaction.amount}</td>
                                <td>{transaction.description}</td>
                                <td>{transaction.transactionDate}</td>
                            </tr>
                        )}
                        </tbody>
                    </table>


                </td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }
}

export default connect(
  (state: ApplicationState) => state.accounts,
    AccountsStore.actionCreators
)(Accounts as any);
