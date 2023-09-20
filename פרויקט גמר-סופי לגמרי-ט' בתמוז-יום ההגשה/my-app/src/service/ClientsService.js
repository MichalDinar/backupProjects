import axios from './axios'


export function getAllClients() {
    return axios.get(`/Clients`,)
        .then(response => response.data)
        .catch(error => { console.log(error) })
}

export function addClient(user) {
    return axios.post(`/Client`, user)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function getByIdClient(id) {
    return axios.get(`/Clients/${id}`)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function updateClient(newUser) {
    return axios.put(`/Clients/${newUser.id}`, newUser)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function deleteClient(id) {
    return axios.delete(`/Clients/${id}`)
        .then(response => response.data)
        .catch(error => console.log(error))
}
