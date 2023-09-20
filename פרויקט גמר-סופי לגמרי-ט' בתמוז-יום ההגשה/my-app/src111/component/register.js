import React, { useRef, useState } from "react";
import { useDispatch } from 'react-redux'
import {addUser} from '../redux/action'

export default function Register(){
    const dispatch = useDispatch()
    const name = useRef()
    const password = useRef()
    const adress = useRef()
    const phone = useRef()

    const [f, setf] = useState(false)
    function save() {
        debugger
        let user1 = { name: name.current.value, password: password.current.value ,adress:adress.current.value,phone:phone.current.value,isManger:false};
        dispatch(addUser(user1))
        setf(true)
    }

  return<>
  { !f && <>
    <input type="text" ref={name} placeholder="הכנס שם"/>
    <input type="password" ref={password} placeholder="הכנס סיסמה"></input>
    <input type="text"ref={adress} placeholder="הכנס כתובת"></input>
    <input type="text" ref={phone} placeholder="הכנס מס' פלאפון"></input>
    <button type="submit" onClick={() => save()} >הוסף</button></>}
    {/* {f &&
    // <Home name={name.current.value}></Home>

    } */}
    </>
}