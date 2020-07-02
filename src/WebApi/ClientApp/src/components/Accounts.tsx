import * as React from "react";
import { connect } from "react-redux";
import { ApplicationState } from "../store";
import * as AccountsStore from "../store/Accounts";
import { Link } from "react-router-dom";
import { NavLink } from "reactstrap";

type AccountsProps =
    AccountsStore.AccountsState
    & typeof AccountsStore.actionCreators;


class Accounts extends React.PureComponent<AccountsProps> {
    componentDidMount() {
        this.ensureDataFetched();
    }

    render() {
        return (
            <React.Fragment>
                <h1>Manage Accounts</h1>
                <p>All your checking accounts.</p>

                <table className="table table-striped" aria-labelledby="tabelLabel">
                    <thead>
                    <tr>
                        <th>Account</th>
                        <th>Current Balance</th>
                    </tr>
                    </thead>
                    <tbody>
                    {this.props.accounts.accounts.map((account: AccountsStore.Account) =>
                        <tr key={account.accountId}>
                            <td>
                                <NavLink tag={Link} className="text-dark" to={`/transactions/${account.accountId}`
}>Transactions</NavLink>
                            </td>
                            <td>{account.currentBalance}</td>
                        </tr>
                    )}
                    </tbody>
                </table>
            </React.Fragment>
        );
    }

    private ensureDataFetched() {
        this.props.requestAccounts();
    }
}

export default connect(
    (state: ApplicationState) => state.accounts,
    AccountsStore.actionCreators
)(Accounts as any);
