import * as React from "react";
import { Form, Field } from "react-final-form";
import NumberInput from "../components/NumberInput";
import { RouteComponentProps } from "react-router";
import Styles from "../Styles"

type DepositProps = RouteComponentProps<{ accountId: string }>;

interface Values {
    amount: number;
}

class Deposit extends React.PureComponent<DepositProps> {

    private async onSubmit(values: Values) {
        const formData = new FormData();

        formData.append("accountId", this.props.match.params.accountId);
        formData.append("amount", values.amount.toString());

        await fetch("api/v1/Accounts/Deposit",
            {
                method: "POST",
                body: formData
            });
    }

    render() {
        return (
            <Styles>
                <h1>Deposit</h1>
                <Form
                    onSubmit={this.onSubmit}
                    initialValues={{ accountId: "", amount: 0 }}
                    render={({ handleSubmit, form, submitting, pristine, values }) => (
                        <form onSubmit={handleSubmit}>
                            <div>
                                <label>Amount</label>
                                <Field<number>
                                    name="amount"
                                    component={NumberInput}
                                    placeholder="amount"
                                />
                            </div>
                            <div className="buttons">
                                <button type="submit" disabled={submitting || pristine}>
                                    Submit
                                </button>
                            </div>
                        </form>
                    )}/>
            </Styles>
);
}
}

export default connect()(Deposit);;;;;;
