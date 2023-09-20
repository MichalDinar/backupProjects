
import axios from './axios'


export function getAllEmployee() {
    return axios.get('/Employee',)
        .then(response => response.data)
        .catch(error => { console.log(error) })
}

export function addEmployee(user) {
    return axios.post( `Employee`, user)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function getByIdEmployee(id) {
    return axios.get(`/StudentInGroup/${id}`)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function updateEmployee(newUser) {
    return axios.put(`/StudentInGroup/${newUser.id}`, newUser)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function deleteEmployee(id) {
    return axios.delete(`/StudentInGroup/${id}`)
        .then(response => response.data)
        .catch(error => console.log(error))
}