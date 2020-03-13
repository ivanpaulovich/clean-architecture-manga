import * as React from 'react';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as TransactionsStore from '../store/Transactions';

type TransactionsProps =
    TransactionsStore.TransactionsState
  & typeof TransactionsStore.actionCreators;


class Transactions extends React.PureComponent<TransactionsProps> {
  public componentDidMount() {
    this.ensureDataFetched();
  }

  public render() {
    return (
      <React.Fragment>
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
              {this.props.transactions.map((transaction: TransactionsStore.Transaction) =>
                  <tr key={transaction.transactionId}>
                      <td>{transaction.transactionId}</td>
                      <td>{transaction.amount}</td>
                      <td>{transaction.description}</td>
                      <td>{transaction.transactionDate}</td>
                  </tr>
              )}
              </tbody>
          </table>
      </React.Fragment>
    );
  }

  private ensureDataFetched() {
    this.props.requestTransactions(2);
  }
}

export default connect(
  (state: ApplicationState) => state.accounts,
    TransactionsStore.actionCreators
)(Transactions as any);
