import axios from './axios'


export function getAllPartialDeliveryToPackage() {
    return axios.get(`/PartialDeliveryToPackage`)
        .then(response => response.data)
        .catch(error => { console.log(error) })
}

export function addClient(user) {
    return axios.post(`/PartialDeliveryToPackage`, user)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function getByIdClient(id) {
    return axios.get(`/PartialDeliveryToPackage/${id}`)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function updateClient(newUser) {
    return axios.put(`/PartialDeliveryToPackage/${newUser.id}`, newUser)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function deleteClient(id) {
    return axios.delete(`/PartialDeliveryToPackage/${id}`)
        .then(response => response.data)
        .catch(error => console.log(error))
}
