import axios from "axios";
const url = 'http://localhost:999/myRecipy/';

export const middlewareRECIPYFunctions = ({ dispatch, getState }) => next => action => {
    if (action.type == 'GET_ALL_RECIPY') {
        debugger
        const getAll = async () => {
            debugger
            const allRecipy = await axios.get('http://localhost:999/myRecipy/getAll')
            action.payload = allRecipy.data
            return next(action)
        }
        getAll()
    }
    if (action.type == 'DELETE_RECIPY') {
        const deleteRecipy = async () => {
            debugger
            let id = action.payload
            action.payload = await (await axios.delete(`http://localhost:999/myRecipy/dellR/${id}`)).data
            return next(action)
        }
        deleteRecipy()
    }
    if (action.type == 'ADD_RECIPY') {
        debugger
        const addRecipy = async () => {
            debugger
            action.payload  =  (await axios.put('http://localhost:999/myRecipy/add', action.payload)).data
            debugger
            return next(action)
        }
        addRecipy()
    }
    if (action.type == 'EDIT_RECIPY') {
        debugger
        const editRecipy = async () => {
            debugger
            let r = await axios.post(`http://localhost:999/myRecipy/post/${action.payload.id}`, action.payload)
            debugger
            action.payload = r.data
            return next(action)
        }
        editRecipy()
    }
    return next(action)
}