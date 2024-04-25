import React, { useEffect } from 'react'
import {  useDispatch, useSelector } from 'react-redux'
import { getIsUserAdmin } from '../user/features/user/isUserAdminSlice'
import AdminMain from './pages/main/AdminMain'
import { setCurrentUser } from '../user/features/user/loginSlice'
import IconGenerator from '../utilities/IconGenerator'
import SecurityGif from './../css/sc-check/security-check.gif'
const AdminApp = () => {
    const dispatch = useDispatch()
    const admin = useSelector(state => state.isUserAdmin)
    document.title = "TEAM TASK-ADMIN"

    useEffect(() => {
        //will set cookie for admin to not request

        dispatch(setCurrentUser())
        dispatch(getIsUserAdmin())
  
    }, [])

    // if ( admin.isLoading) {
    //     return (
    //         <div className='w-screen h-screen flex  justify-center items-center'>
    //             <div className='gap-5 flex  flex-col items-center justify-center'>
    //                 <img className='w-72' src={SecurityGif} alt="" />

    //                 <span className='text-5xl'>GÜVENLİK KONTROLLERİ YAPILIYOR. LÜTFEN BEKLEYİNİZ</span></div>
    //         </div>
    //     )
    // }
    // if (  admin.isAdmin) {
    //     return (
    //         <AdminMain />
    //     )
    // } else {
    //     return (
    //         <>GÖRÜNÜŞE GÖRE ERİŞİM YETKİNİZ YOK</>
    //     )
    // }
    return (
        <AdminMain />

    )


}

export default AdminApp