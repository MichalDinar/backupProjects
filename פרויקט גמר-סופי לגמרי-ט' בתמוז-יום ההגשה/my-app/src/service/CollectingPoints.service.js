// PrametersForStudent

import axios from './axios'


export function getAllPrametersForStudent() {
    return axios.get('/PrametersForStudent',)
        .then(response => response.data)
        .catch(error => { console.log(error) })
}

export function addCollectingPoints(colPoint) {
    return axios.post(`/CollectingPoint`, colPoint)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function getByIdPrameterForStudent(id) {
    return axios.get(`/PrametersForStudent/${id}`)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function updatePrameterForStudent(newUser) {
    return axios.put(`/PrametersForStudent/${newUser.id}`, newUser)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function deletePrametersForStudent(id) {
    return axios.delete(`/PrametersForStudent/${id}`)
        .then(response => response.data)
        .catch(error => console.log(error))
}
