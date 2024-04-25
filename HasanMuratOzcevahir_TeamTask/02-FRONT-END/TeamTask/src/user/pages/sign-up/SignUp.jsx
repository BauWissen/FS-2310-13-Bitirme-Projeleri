import React  from 'react'
import { PageLayout, BottomSlice, LeftDescription, PageHolder, FormHolder, FormTitle, SubmitForm, SubmitButton, FormInput,ToOtherPage } from '../../components/globals/login-signup/LoginSignUpComponentExport';
import { yupSignUpSchema } from '../../../utilities/yupSignUpSchema';
import { useDispatch, useSelector } from 'react-redux';
import { signUp } from '../../features/user/signUpSlice';
import { toast } from 'react-toastify';
import { useNavigate } from 'react-router-dom';

const SignUp = () => {
  const navigateToLogin = useNavigate()

  const signUpResult = useSelector(state => state.signUp)
  const dispatch = useDispatch()
  const handleSubmit = async (e) => {
    e.preventDefault();
    let formObj = Object.fromEntries(new FormData(e.target).entries())
    try {
      let validForm = await yupSignUpSchema.isValid(formObj)
      if (!validForm) {
        dispatch(signUp(formObj))

      }
      else {
        await yupSignUpSchema.validate(formObj, { abortEarly: false })
      }
    }
    catch (err) {
      const errorList = <div className='flex flex-col'>{err.errors.map((item, i) => <span key={i}>{item}</span>)}</div>
      toast.error(<>{errorList}</>, { autoClose: 5000, position: "top-right" })
    }

  }
  return (
    <PageHolder>
      <PageLayout>
        <LeftDescription />
        <FormHolder>
          <FormTitle title="Birlikte çalışmak için kaydol" />
          <SubmitForm handleSubmit={handleSubmit}>
            <FormInput text="Adın" iName="FirstName" pHolder="Murat" type="text" />
            <FormInput text="Soyadın" iName="LastName" pHolder="Özcevahir" type="text" />
            <FormInput text="Email" iName="Email" pHolder="teamtask@tt.com" type="text" />
            <FormInput text="Şifre" iName="Password" pHolder="123456" type="text" />
            <FormInput text="Şifre tekrar" iName="RePassword" pHolder="123456" type="text" />
            <SubmitButton disabled={signUpResult.isLoading} textValue="Kaydol" />
            <ToOtherPage link="login" text="Hesabın varsa" linkText="giriş yap" />
          </SubmitForm>
        </FormHolder>
      </PageLayout>
      <BottomSlice />
    </PageHolder>

  )
}
export default SignUp