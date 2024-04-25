import React from 'react'
import { Link } from 'react-router-dom'

const ToOtherPage = ({ link, text, linkText }) => {
    return (
        <span className='text-slate-400'>
           <span>{text} </span>
            <Link to={`/${link}`} className='text-green-600 font-bold transition-all duration-300 hover:text-green-700'>
               {linkText}
            </Link>
        </span>
    )
}

export default ToOtherPage