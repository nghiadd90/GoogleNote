import React, { Component } from 'react';
import connect from 'react-redux';
import { postLogin } from '../../actions/authActions';

class Register extends Component {
    constructor(props) {
        super(props);

        // this.onDelete = this.onDelete.bind(this);

        this.state = {
            email: "",
            password: ""
        }
    }

    handleChange = event => {
        this.setState({
            [event.target.name]: event.target.value
        });
    }

    handleSubmit = event => {
        event.PreventDefault();
        this.props.loginUser(this.state)
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <h1>Sign Up For An Account</h1>
        
                <label>Username</label>
                <input
                name='username'
                placeholder='Username'
                value={this.state.username}
                onChange={this.handleChange}
                /><br/>
        
                <label>Password</label>
                <input
                type='password'
                name='password'
                placeholder='Password'
                value={this.state.password}
                onChange={this.handleChange}
                /><br/>
        
                <button type='button'>Submit</button>
            </form>
        )
    }
}
    
const mapDispatchToProps = dispatch => ({
    loginUser: userInfo => dispatch(loginUser(userInfo))
})

export default connect(null, mapDispatchToProps)(Register);
