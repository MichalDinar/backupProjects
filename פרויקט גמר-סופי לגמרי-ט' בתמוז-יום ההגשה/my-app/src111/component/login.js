import React, {  useRef } from "react";
import { useSelector, useDispatch } from 'react-redux'
import {  getUSERNamePassord } from "../redux/action";

export default function Login() {
    const dispatch = useDispatch()
    const name = useRef()
    const password = useRef()
    const user = useSelector(state => state.userR.user)
    // const Manger = useSelector(state => state.userR.isManger)
    function save() {
        debugger
        let user1 = { name: name.current.value, password: password.current.value };
        dispatch(getUSERNamePassord(user1))
    }
    function move() {
        debugger
        var elem = document.getElementById("myBar");
        var width = 1;
        var id = setInterval(frame, 5);
        function frame() {
            if (width >= 100) {
                clearInterval(id);
                save()
            } else {
                width++;
                elem.style.width = width + '%';
            }
        }
    }

    return (<>
        {user?.name}
        {!user?.name && <>
            <div>
                <input ref={name} type="text" placeholder="הכנס שם"/>
                <input ref={password} type="text" placeholder="הכנס סיסמה"/>
                <button type="submit" onClick={() => move()} >זהה אותי</button>
            </div>
            <br></br>
            <div id="myProgress">
                <div id="myBar"></div>
            </div>
        </>
        }
    </>
    )
}