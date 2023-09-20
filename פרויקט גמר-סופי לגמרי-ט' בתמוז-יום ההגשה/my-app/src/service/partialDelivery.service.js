import React from 'react'

import axios from './axios'


export function getAllPartialDelivery(id) {
    
    return axios.get(`/dailyRoute?employeeId=${id}`)
        .then(response => response.data)
        .catch(error => { console.log(error) })
}

export function addClient(user) {
    return axios.post(`/PartialDelivery`, user)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function getByIdClient(id) {
    return axios.get(`/PartialDelivery/${id}`)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function updateClient(newUser) {
    return axios.put(`/PartialDelivery/${newUser.id}`, newUser)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function deleteClient(id) {
    return axios.delete(`/PartialDelivery/${id}`)
        .then(response => response.data)
        .catch(error => console.log(error))
}
