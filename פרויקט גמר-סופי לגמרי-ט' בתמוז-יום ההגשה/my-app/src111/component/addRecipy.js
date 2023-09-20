import React, { useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from 'react-redux'
import { addLoveRecipy, addRecipy, editRecipy } from "../redux/action";

export default function AddRecipy(props) {

    const dispatch = useDispatch()
    const name = useRef()
    const describe = useRef()
    const pic = useRef()
    const rama = useRef()
    const time = useRef()
    const sog = useRef()
    const nameR = useRef()
    const amountR = useRef()
    const password = useRef()

    const user = useSelector(state => state.userR.user)

    const [raciv, setraciv] = useState(false)
    const [arrRaciv, setarrRaciv] = useState([])
    const [add, setAdd] = useState(true)

    useEffect(() => {
        
        if (props.name) {
            name.current.value = props.name
            describe.current.value = props.describe
            pic.current.value = props.pic
            rama.current.value = props.rama
            time.current.value = props.time
            sog.current.value = props.sog
            password.current.value = props.password
            if (props.arrR)
                setarrRaciv(props.arrR)
        }
    }, [])

    function save() {
        debugger
        setraciv(false)
        if (props && props.add)
            props.add(false)
        setAdd(false)
        let recipy = { name: name.current.value, describe: describe.current.value, pic: pic.current.value, rama: rama.current.value, time: time.current.value, sog: sog.current.value, password: password.current.value, raciv: arrRaciv, userId: (user._id ? user._id : user.id) };
        dispatch(addRecipy(recipy))
    }
    //שמירת הרכיבים בתוך מערך
    function saveR() {
        let r = { nameR: nameR.current.value, amount: amountR.current.value }
        setarrRaciv(arrRaciv.concat(r))
        setraciv(false)
    }
    function a() {
        setraciv(true)
    }
    //לשלוח לעריכת מתכון
    function editR() {
        debugger
        let recipy = { _id: props.id, name: name.current.value, describe: describe.current.value, pic: pic.current.value, rama: rama.current.value, time: time.current.value, sog: sog.current.value, password: password.current.value, raciv: arrRaciv };
        if (props.setEdit)
            props.setEdit(false)
        if (props.setId)
            props.setId(null)
        if (!props.recipyPersonal) {
            dispatch(editRecipy(recipy))
        }
        else {
            let user1 = {
                id: user._id ? user._id : user.id, name: user.name, password: user.password, adress: user.adress, phone: user.phone, isManger: user.isManger,
                matcon: user.matcon.filter(i => i._id != props.id).concat(recipy)
            };
            dispatch(addLoveRecipy(user1))
        }
    }
    return (
        <>
            <>{add ? <>

                <input type="text" ref={name} placeholder="הכנס שם מתכון" />
                <input type="text" ref={describe} placeholder="הכנס תאור" />
                <input type="text" ref={pic} placeholder="הכנס תמונה" />
                <input type="text" ref={rama} placeholder="הכנס רמת קושי" />
                <input type="number" ref={time} placeholder="הכנס זמן הכנה" />
                <input type="text" ref={sog} placeholder="הכנס סוג" />
                <input type="text" ref={password} placeholder="הכנס סיסמה" />
                <br></br>
                <button onClick={() => a()}>הוספת רכיב</button>
                {add && raciv && <>
                    <input type="text" ref={nameR} placeholder="שם רכיב" />
                    <input type="text" ref={amountR} placeholder="כמות" />
                    <button onClick={() => saveR()}>הוסף</button>
                </>
                }
            </>
                : <button onClick={() => { setAdd(true) }}>הוספת עוד מוצר</button>
            }
                <br></br>
            </>
            {props.arrR &&
                <>
                    <p>{arrRaciv && arrRaciv.map((r) => {
                        return <>
                            <input type="text" defaultValue={r.nameR} />
                            <input type="text" defaultValue={r.amount} />
                        </>
                    })}
                    </p>
                </>
            }
            <br></br>
            {!props.name ?
                <button type="submit" onClick={() => save()} >הוסף</button>
                : <button type="submit" onClick={() => editR()} >שמור שינוים</button>
            }
        </>
    )
}