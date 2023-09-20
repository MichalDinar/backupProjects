
import { Password } from '@mui/icons-material'
import axios from './axios'

export function openDay(bussinesDay) {///////////////לא עשיתי עדיין
//   https://localhost:7182/api/User/SignIn?mail=1234%40gmail.com&password=1234
//https://localhost:7182/api/Algorithm/Algorithm
      console.log('open:'+bussinesDay.open+' close: '+bussinesDay.close);
      // var result= axios.post(`/Algorithm/Algorithm?open=${startTime}&close=${endTime}`)
      
      bussinesDay.open=formatDate(bussinesDay.open)
      bussinesDay.close=formatDate(bussinesDay.close)

      console.log('open:'+bussinesDay.open+' close: '+bussinesDay.close);
      
      var result= axios.post(`/Algorithm/Algorithm`,bussinesDay)
      //console.log("result "+result.then(r=>r.data.user.id));
      return result
        .then(response => response.data)
        .catch(error => console.log(error))
}
function formatDate(time) {
  const now = new Date();
  const year = now.getFullYear();
  const month = String(now.getMonth() + 1).padStart(2, '0');
  const day = String(now.getDate()).padStart(2, '0');
  const [hours, minutes] = time.split(':');
  return `${year}-${month}-${day}T${hours}:${minutes}`;
}

export function login(email, password) {
  console.log("user.service " + email + password)
  // https://localhost:7182/api/User/SignIn?mail=1234%40gmail.com&password=1234
  var result = axios.get(`/User/SignIn?mail=${email}&password=${password}`)
    .then(response => {
      debugger
      const { userId, userType } = response.data;
      console.log("userId: " + userId + " userType: " + userType);
      return response;
    })
    .catch(error => console.log(error));
  return result;
}


export function GetAllClient(email, password) {
  console.log("user.service " + email + password)
  // https://localhost:7182/api/User/SignIn?mail=1234%40gmail.com&password=1234
  var result = axios.get(`/User/SignIn?mail=${email}&password=${password}`)
    .then(response => {
      const { userId, userType } = response.data;
      console.log("userId: " + userId + " userType: " + userType);
      return response;
    })
    .catch(error => console.log(error));
  return result;
}
