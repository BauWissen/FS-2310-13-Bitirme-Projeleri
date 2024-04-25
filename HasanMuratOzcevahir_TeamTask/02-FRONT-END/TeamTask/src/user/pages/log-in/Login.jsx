
import React, { useEffect } from 'react'
import { useNavigate } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { loginRequest, setLoginAttempt } from '../../features/user/loginSlice';
import { BottomSlice, FormHolder, FormInput, FormTitle, LeftDescription, PageHolder, PageLayout, SubmitButton, SubmitForm, ToOtherPage } from '../../components/globals/login-signup/LoginSignUpComponentExport';


const Login = () => {
  let loginDispatch = useDispatch()
  const navigate = useNavigate()
  const currentLoggedIn = useSelector(state => state.currentUser)

  const handleSubmit = (e) => {
    e.preventDefault();

    const { Email, Password, RememberMe } = e.target.elements
    let userInfo = {
      Email: Email.value,
      Password: Password.value,
      RememberMe: RememberMe.checked
    }
    loginDispatch(loginRequest(userInfo))

  }
  useEffect(() => {

    if (currentLoggedIn.user) {
      navigate("/dashboard/")
      return
    }
    loginDispatch(setLoginAttempt(false))
  }, [currentLoggedIn.user])

  return (
    <PageHolder>
      <PageLayout>
        <LeftDescription />
        <FormHolder>
          <div className='absolute bottom-0  left-1/2 -translate-x-1/2 text-2xl text-center bg-opacity-50 text-black p-4 bg-rose-600 w-full'>
          Email : muratoz@gmail.com Şifre : 123456
          </div>
          <FormTitle title="Birlikte çalışmaya başla" />
          <SubmitForm handleSubmit={handleSubmit}>
            <FormInput text="Email" iName="Email" pHolder="muratoz@gmail.com" type="text" />
            <FormInput text="Şifre" iName="Password" pHolder="123456" type="text" />

            <div className='flex gap-2'>
              <input type="checkbox" name="RememberMe" id="RememberMe" className='accent-orange-300' />
              <label htmlFor="RememberMe">  Beni hatırla</label>

            </div>
            <SubmitButton disabled={currentLoggedIn.isLoading} textValue="Giriş yap" />
            <ToOtherPage link="signup" text="Hesabın yoksa" linkText="kaydol" />
          </SubmitForm>
        </FormHolder>
      </PageLayout>
      <BottomSlice />
    </PageHolder>

  )
}
export default Login