import * as yup from 'yup';


export const yupSignUpSchema = yup.object().shape({
    Email: yup.string().email("Email geçersiz.").required("Email zorunlu.").max(100, "Email en fazla 100 karakter."),
    FirstName: yup.string().required("Adın zorunlu.").min(2, "Ad en az 2 karakter").max(20, "Ad en fazla 15 karakter.").strict(),
    LastName: yup.string().required("Soyadın zorunlu.").min(2, "Soyad en az 2 karakter").max(40, "Soyad en fazla 15 karakter."),
    Password: yup.string().required('Şifre zorunlu.').min(6, "Şifre en az 6 karakter").max(16, "Şiifre en fazla 16 karakter.")
        .matches(
            /^(?=.*[a-z])/,
            "Şifre en az bir küçük harf içermelidir"
        )
        .matches(
            /^(?=.*[A-Z])/,
            "Şifre en az bir büyük harf içermelidir"
        )
        .matches(
            /^(?=.*[0-9])/,
            "Şifre en az bir sayı içermelidir"
        )
        .matches(
            /^(?=.*[!@#\$%\^&\*])/,
            "Şifre en az bir özel karakter içermelidir"
        ),
    RePassword: yup.string().required('Şifre tekrarı zorunlu').oneOf([yup.ref('Password'), null], 'Şifreler uyumsuz.'),
})
