import React, { useState } from 'react'
import { useLocation } from 'react-router-dom'
import FormGroup from '../../../user/components/globals/login-signup/FormGroup'
import FormInput from '../../../user/components/globals/login-signup/FormInput'
import { useDispatch } from 'react-redux'
import { adminEditUser } from '../../slices/adminEditUserSlice'

const AdminEditUser = () => {
  const location = useLocation()
  const [userInfo, setuserInfo] = useState(location.state)
  const dispatch = useDispatch()
  console.log(location.state, " location")

  const handleChange = (e) => {

    const { name, value,type,checked } = e.target
    // setuserInfo({ ...userInfo, [name]: value })
    setuserInfo(prevData => ({
      ...prevData,
      [name]: type === 'checkbox' ? checked : value
    }))

  }
  console.log(userInfo, " userinfo after change hope sp")
  return (
    <div className='flex justify-center w-full p-5'>
      <div className='flex flex-col gap-2 lg:w-1/3'>
        <input type="text" disabled value={'ID '+userInfo.id} className='disabled:bg-gray-200 text-gray-400 text-sm border-none rounded-md'/>
        <FormGroup>
          <span>Kullanıcı adı</span>
          <input type='text' name="userName" value={userInfo.userName} onChange={handleChange} />
        </FormGroup>
        <FormGroup>
          <span>Email</span>
          <input type='text' name="email" value={userInfo.email} onChange={handleChange} />
        </FormGroup>
        <FormGroup>
          <div>
            <input id='lockoutEnabled' type="checkbox" name='lockoutEnabled'  checked={userInfo.lockoutEnabled} onChange={handleChange} />
            <label htmlFor='lockoutEnabled'>Kilitleme etkin mi?</label>
          </div>
          <div>
            <input id='emailConfirmed' type="checkbox" name='emailConfirmed' checked={userInfo.emailConfirmed}  onChange={handleChange} />
            <label htmlFor='emailConfirmed'>Email onaylı mı?</label>
          </div>
          <div>
            <input id='twoFactorEnabled' type="checkbox" name='twoFactorEnabled' checked={userInfo.twoFactorEnabled}  onChange={handleChange} />
            <label htmlFor='twoFactorEnabled'>İki aşamalı doğrulama?</label>
            
          </div>
          <div>
          <input id='phoneNumberConfirmed' type="checkbox" name='phoneNumberConfirmed' checked={userInfo.phoneNumberConfirmed}  onChange={handleChange} />
            <label htmlFor='phoneNumberConfirmed'>Telefon numarası onaylı mı?</label>
          </div>
        </FormGroup>

        <FormGroup>
        <input type="text" name='phoneNumber' value={userInfo.phoneNumber}  onChange={handleChange} />


        </FormGroup>

        <FormGroup>
        </FormGroup>



        <button type='button' onClick={()=>{dispatch(adminEditUser(userInfo))}} className='bg-sky-400 py-2 px-4'>Değişiklikleri kaydet</button>
      </div>
    </div>
  )
}

export default AdminEditUser