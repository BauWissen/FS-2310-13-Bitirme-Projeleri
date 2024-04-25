import { Link  } from "react-router-dom";
import IconGenerator from "../IconGenerator";


import React, { useEffect } from 'react'
import { useDispatch } from "react-redux";
import { adminRemoveUser, setIsDeleted } from "../../admin/slices/adminRemoveUserSlice";
import { adminToggleConfirmUserEmail } from "../../admin/slices/adminToggleConfirmUserEmailSlice";
import { adminGetUserList } from "../../admin/slices/adminGetUserListSlice";

const EditSelectedUser = ({ user }) => {
    console.log(user, " selected")
    return (
        <Link to={{ pathname: '/admin/edituser'  }} state={user} className="text-sky-300 transition-all duration-300 hover:text-sky-500 cursor-pointer"> <IconGenerator name="fa-solid fa-pen" /></Link>
    )
}
const ToggleconfirmUserEmail = ({ confirmed, userId }) => {

    const dispatch = useDispatch()
    return (
        <>
            <div className={`${confirmed ? 'text-green-500' : 'text-rose-500'}`}>
                <span onClick={() => {

                    dispatch(adminToggleConfirmUserEmail(userId))

                }}>

                    {confirmed ? 'Evet' : 'Hayır'}

                </span>

            </div>


        </>
    )
}
const RemoveUser = ({ userId }) => {
    const dispatch = useDispatch()
    console.log(userId, "uid from dto")

    return (
        <span onClick={() => {
            confirm("bu işlem geri alınamaz, silmek istiyor musunuz") && dispatch(adminRemoveUser(userId))


        }} className="cursor-pointer transition-all duration-300 hover:text-rose-600 text-rose-300">
            <IconGenerator name="fa-solid fa-trash" />
        </span>
    )
}

export const userDTC = [
    {
        name: 'Id',
        cell: row => row.id,
        selector: row => row.id,

    },
    {
        name: 'Email',
        cell: row => row.email,
        selector: row => row.email,
        sortable: true
    },
    {
        name: 'Kullanıcı Adı',
        cell: row => row.userName,
        selector: row => row.userName,
        sortable: true
    },
    {
        name: 'Telefon Numarası',
        cell: row => row.phoneNumber,
        selector: row => row.phoneNumber,
    },
    {
        name: 'Telefon Numarası Onaylı?',
        cell: row => row.phoneNumberConfirmed ? 'Evet' : 'Hayır',
        selector: row => row.phoneNumberConfirmed,
    },
    {
        name: 'Email Onaylı?',
        cell: row => <ToggleconfirmUserEmail confirmed={row.emailConfirmed} userId={row.id} />,
        selector: row => row.emailConfirmed,
        sortable: true
    },
    {
        name: 'Kilitleme etkin?',
        cell: row => row.lockoutEnabled ? 'Evet' : 'Hayır',
        selector: row => row.lockoutEnabled,
    },
    {
        name: 'Giriş Denemesi',
        cell: row => row.accessFailedCount,
        selector: row => row.accessFailedCount,
    },
    {
        name: 'Eylem',
        cell: row => <div className="text-2xl flex  gap-2">


            <EditSelectedUser user={row} />
            <RemoveUser userId={row.id} />



        </div>,
        selector: row => row.accessFailedCount,
    },

];
