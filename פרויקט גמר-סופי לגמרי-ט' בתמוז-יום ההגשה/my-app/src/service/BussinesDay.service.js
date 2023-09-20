
import axios from './axios'


export function getAllBussinesDay() {
    return axios.get('/StudentGroup',)
        .then(response => response.data)
        .catch(error => { console.log(error) })
}


export function addBusinessDay(order) {
    const [packageId] = order;
    const data = {
      date: new Date(),
      packageId: packageId,
    };
    return axios.post('/BusinessDay', data)
      .then(response => response.data)
      .catch(error => console.log(error));
  }

export function getByIdBussinesDay(id) {
    return axios.get(`/StudentGroup/${id}`)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function updateBussinesDay(newUser) {
    return axios.put(`/StudentGroup/${newUser.id}`, newUser)
        .then(response => response.data)
        .catch(error => console.log(error))
}

export function deleteBussinesDay(id) {
    return axios.delete(`/StudentGroup/${id}`)
        .then(response => response.data)
        .catch(error => console.log(error))
}
