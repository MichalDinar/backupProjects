
import axios from './axios'


export function getAllOrder() {
    return axios.get('/Student',)
        .then(response => response.data)
        .catch(error => { console.log(error) })
}

export function addOrder(order) {
    // axios.post(`/`,order)
    return axios.post( `/Package`, order)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function getByIdStudent(id) {
    return axios.get(`/Student/${id}`)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function updateStudent(newUser) {
    return axios.put(`/Student/${newUser.id}`, newUser)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function deleteStudent(id) {
    return axios.delete(`/Student/${id}`)
        .then(response => response.data)
        .catch(error => console.log(error))
}