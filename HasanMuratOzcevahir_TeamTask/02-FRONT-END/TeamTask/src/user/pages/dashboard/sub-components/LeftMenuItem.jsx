import React from 'react'
import {   NavLink } from 'react-router-dom'
import IconGenerator from '../../../../utilities/IconGenerator'

const LeftMenuItem = ({ icon, link }) => {

    return (
     
        //will be fixed
        <NavLink end className={({ isActive }) => isActive ?'bg-orange-400  p-1 lg:p-4 flex  justify-center items-center w-full h-max rounded-md transition-all duration-300 hover:bg-orange-500 ':'bg-orange-200 p-1 lg:p-4 flex  justify-center items-center w-full h-max rounded-md transition-all duration-300 hover:bg-orange-500'} to={`/dashboard/${link}`}>
            <IconGenerator name={icon} style="text-3xl text-zinc-600"  />
        </NavLink>
    )
}

export default LeftMenuItem