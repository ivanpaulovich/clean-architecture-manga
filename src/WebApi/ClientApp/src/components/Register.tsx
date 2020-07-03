import * as React from "react";
import { connect } from "react-redux";
import { Form, Field } from "react-final-form";
import TextInput from "../components/TextInput";
import NumberInput from "../components/NumberInput";
import Styles from "../Styles"

interface Values {
    firstName: string;
    ssn: string;
    initialAmount: number;
}

const onSubmit = async (values: Values) => {
    const formData = new FormData();

    formData.append("firstName", values.firstName);
    formData.append("ssn", values.ssn);
    formData.append("initialAmount", values.initialAmount.toString());

    await fetch("api/v1/Customers",
        {
            method: "POST",
            body: formData
        });
};

const Register: React.FC = () => (
    <Styles>
        <h1>Register an Account</h1>
        <Form
            onSubmit={onSubmit}
            initialValues={{ firstName: "", ssn: "", initialAmount: 0 }}
            render={({ handleSubmit, form, submitting, pristine, values }) => (
                <form onSubmit={handleSubmit}>
                    <div>
                        <label>First Name</label>
                        <Field<string>
                            name="firstName"
                            component={TextInput}
                            placeholder="First Name"
                        />
                    </div>
                    <div>
                        <label>SSN</label>
                        <Field<string>
                            name="ssn"
                            component={TextInput}
                            placeholder="SSN"
                        />
                    </div>
                    <div>
                        <label>Initial Amount</label>
                        <Field<number>
                            name="initialAmount"
                            component={NumberInput}
                            placeholder="Initial Amount"
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

export default connect()(Register);
