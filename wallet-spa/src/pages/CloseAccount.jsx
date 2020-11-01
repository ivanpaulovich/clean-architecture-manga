import React, { } from "react";
import accountsService from "../store/accountsService";
import { withRouter } from "react-router";
import PageBase from "../components/PageBase";
import { Link } from "react-router-dom";
import Button from "@material-ui/core/Button";
import { grey } from "@material-ui/core/colors";
import {Redirect} from "react-router-dom";

class CloseAccount extends React.Component {

  static displayName = CloseAccount.name;

  constructor(props) {
    super(props);

    this.state = {
      accountId: this.props.match.params.accountId,
      submitted: false
    }

    this.handleInputChange = this.handleInputChange.bind(this);
    this.saveCloseAccount = this.saveCloseAccount.bind(this);
    this.newCloseAccount = this.newCloseAccount.bind(this);
  }

  handleInputChange = event => {
    const { name, value } = event.target;
    this.setState(
      () => {
        return {
          [name]: value
        };
      })
  };

  saveCloseAccount = () => {
    accountsService
      .closeAccount(this.state.accountId)
      .then(response => {
        this.setState({
          accountId: response.data.accountId,
          submitted: true
        });
      })
      .catch(e => {
        console.log(e);
      });
  };

  newCloseAccount = () => {
    this.setState({
      accountId: this.props.match.params.accountId,
      submitted: false
    });
  };

  render() {

    const styles = {
      toggleDiv: {
        marginTop: 20,
        marginBottom: 5
      },
      toggleLabel: {
        color: grey[400],
        fontWeight: 100
      },
      buttons: {
        marginTop: 30,
        float: "right"
      },
      saveButton: {
        marginLeft: 5
      }
    };

    return (

      <PageBase title="Close Account" navigation="My Accounts / Close Account">

        {this.state.submitted ? (
          <Redirect to={`/dashboard`} push />
        )  : (
            <div style={styles.buttons}>
              <Link to="/">
                <Button variant="contained">Cancel</Button>
              </Link>

              <Button
                style={styles.saveButton}
                variant="contained"
                type="submit"
                color="primary"
                onClick={this.saveCloseAccount}
              >
                Save
                      </Button>
            </div>
          )}

      </PageBase>
    );
  }
}

export default withRouter(CloseAccount);