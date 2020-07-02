import * as React from "react";
import { connect } from "react-redux";
import { ApplicationState } from "../store";
import * as TransactionsStore from "../store/Transactions";
import { RouteComponentProps } from "react-router";

type TransactionsProps =
    TransactionsStore.TransactionsState
    & typeof TransactionsStore.actionCreators
    & RouteComponentProps<{ accountId: string }>;


class Transactions extends React.PureComponent<TransactionsProps> {
    componentDidMount() {
        this.ensureDataFetched();
    }

    render() {
        console.log(this.props.account);

        return (
            <React.Fragment>
                <table className="table table-striped" aria-labelledby="tabelLabel">
                    <thead>
                    <tr>
                        <th>Credit</th>
                        <th>Amount</th>
                        <th>Description</th>
                        <th>Transaction Date</th>
                    </tr>
                    </thead>
                    <tbody>
                    {
                        this.props.account.credits.map((transaction: TransactionsStore.Credit) =>
                            <tr key={transaction.transactionId}>
                                <td>{transaction.transactionId}</td>
                                <td>{transaction.amount}</td>
                                <td>{transaction.description}</td>
                                <td>{transaction.transactionDate}</td>
                            </tr>
                        )
                    }
                    </tbody>
                </table>

                <table className="table table-striped" aria-labelledby="tabelLabel">
                    <thead>
                    <tr>
                        <th>Debit</th>
                        <th>Amount</th>
                        <th>Description</th>
                        <th>Transaction Date</th>
                    </tr>
                    </thead>
                    <tbody>
                    {
                        this.props.account.debits.map((transaction: TransactionsStore.Credit) =>
                            <tr key={transaction.transactionId}>
                                <td>{transaction.transactionId}</td>
                                <td>{transaction.amount}</td>
                                <td>{transaction.description}</td>
                                <td>{transaction.transactionDate}</td>
                            </tr>
                        )
                    }
                    </tbody>
                </table>
            </React.Fragment>
        );
    }

    private ensureDataFetched() {
        this.props.requestTransactions(this.props.match.params.accountId);
    }
}

export default connect(
    (state: ApplicationState) => state.accountDetails,
    TransactionsStore.actionCreators
)(Transactions as any);
