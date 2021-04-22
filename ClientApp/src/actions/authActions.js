export const postLogin = user => {
    return dispatch => {
      return fetch("http://localhost:5001/api/auth/login", {
        method: "POST",
        headers: {
          'Content-Type': 'application/json',
          Accept: 'application/json',
        },
        body: JSON.stringify({user})
      })
        .then(resp => resp.json())
        .then(data => {
          if (data.message) {
            // Here you should have logic to handle invalid creation of a user.
            // This assumes your Rails API will return a JSON object with a key of
            // 'message' if there is an error with creating the user, i.e. invalid username
          } else {
            localStorage.setItem("accessToken", data.accessToken)
            dispatch(loginUser(data.user))
          }
        })
    }
  }
  
export const USER_LOGIN = 'USER_LOGIN';
export const loginUser = user => ({
    type: USER_LOGIN,
    payload: { user }
});
