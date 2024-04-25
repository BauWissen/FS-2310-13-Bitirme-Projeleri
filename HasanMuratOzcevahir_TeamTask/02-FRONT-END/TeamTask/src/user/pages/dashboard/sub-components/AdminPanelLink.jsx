import React from 'react'
import { NavLink } from 'react-router-dom'
import IconGenerator from '../../../../utilities/IconGenerator'

const AdminPanelLink = () => {
    return (
        <NavLink to="../admin" className="text-sky-600 lg:text-4xl bg-zinc-700 w-full flex flex-col justify-center items-center p-2  h-full rounded-md hover:bg-zinc-800 hover:text-orange-400 transition-all duration-300">
            <IconGenerator name="fa-solid fa-screwdriver-wrench" />
            <span className='text-xs'>Admin</span>
        </NavLink>
    )
}

export default AdminPanelLink