import axios from 'axios';

const AUTH_URL = "http://localhost:5001/api/auth";

class AuthService
{
    login(email, password) {
        return axios
            .post(AUTH_URL + '/login', {email, password})
            .then(res => {
                if (res.data.accessToken) {
                    localStorage.setItem("user", JSON.stringify(res.data));
                }
                return res.data;
            })
    }

    logout() {
        localStorage.removeItem("user");
    }

    register(email, password) {
        return axios
            .post(AUTH_URL + '/register', {email, password});
    }
}

export default new AuthService();
