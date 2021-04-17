import axios from 'axios';

export const GET_ALL_NOTES_REQUEST = 'GET_ALL_NOTES_REQUEST';
export const GET_ALL_NOTES_SUCCESS = 'GET_ALL_NOTES_SUCCESS';
export const GET_ALL_NOTES_ERROR = 'GET_ALL_NOTES_ERROR';

const getNotesSuccess = payload => ({
    type: GET_ALL_NOTES_SUCCESS,
    payload
});

const getNotesError = payload => ({
    type: GET_ALL_NOTES_ERROR,
    payload
});

export const getAllNotes = () => dispatch => {
    dispatch({type: GET_ALL_NOTES_REQUEST});
    return axios.get('api/note').then(res => {
        const response = res.data;
        dispatch(getNotesSuccess(response));
    }).catch(err => {
        dispatch(getNotesError('Something went wrong'));
        return Promise.reject({});
    });
}