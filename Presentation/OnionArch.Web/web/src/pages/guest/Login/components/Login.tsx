import { useState } from 'react'
import { Link } from 'react-router-dom';
//mui components
import { Button, Paper, Stack, styled, TextField, Typography } from '@mui/material'
//icons
import LoginIcon from '@mui/icons-material/Login';
//models
import { UserLoginRequest } from '../../../../models/paramaterModels/Authentication/UserLoginRequest';
//helpers
import AuthenticationAPI from '../../../../APIs/AuthenticationAPI';
import toast from 'react-hot-toast';
import { Encrypt } from '../../../../utils/Cryption';
import { setCookie } from '../../../../utils/Cookie';
import { AxiosResponse } from 'axios';

type LoginForm = {
    email: string,
    password: string
}

const Login = () => {

    const [form, setForm] = useState<LoginForm>({
        email: "",
        password: ""
    })
    const [buttonBlocker, setButtonBlocker] = useState(false)

    const handleChange = (e: any) => {
        const { name, value } = e.target

        setForm({
            ...form, [name]: value
        })
    }

    const handleLogin = async () => {
        setButtonBlocker(true)

        const userLoginRequest: UserLoginRequest = {
            email: form.email,
            encryptedPassword: await Encrypt(form.password)
        }

        const response: AxiosResponse = await AuthenticationAPI.Login(userLoginRequest)
        let data = response.data

        if (response.status === 200) {
            setCookie("jwt", data.accessToken, data.accessTokenExpireDate)
            setCookie("refresh", data.refreshToken, data.refreshTokenExpireDate)

            toast.success("Login successful")
            setTimeout(() => {
                window.location.href = "/"
            }, 1000)
        }
        else if (response.status === 401) {
            toast.error("Invalid user credentials")
        }
        else {
            toast.error("Internal server error occured")
        }

        setTimeout(() => {
            setButtonBlocker(false)
        }, 1000)
    }

    return (
        <StyledPaper elevation={2}>
            <FormWrapperStack direction="column" spacing={4}>

                <ComponentGroupStack direction="column" spacing={1}>
                    <LoginIcon sx={{ fontSize: 32 }} />
                    <Typography variant='h5'>Sign in</Typography>
                </ComponentGroupStack>

                <ComponentGroupStack direction="column" spacing={2}>
                    <TextField
                        name="email"
                        label="Email"
                        type="email"
                        size='small'
                        fullWidth
                        value={form.email}
                        onChange={handleChange}
                    />

                    <TextField
                        name="password"
                        label="Password"
                        type='password'
                        size='small'
                        fullWidth
                        value={form.password}
                        onChange={handleChange}
                    />
                </ComponentGroupStack>

                <ComponentGroupStack direction="column" spacing={2}>
                    <Button
                        variant='contained'
                        fullWidth
                        disabled={buttonBlocker}
                        onClick={handleLogin}
                    >
                        Sign In
                    </Button>

                    <Link to="/register" style={{ textDecoration: "none" }}>
                        <Button size='small' >Don't have an account? Sign up</Button>
                    </Link>
                </ComponentGroupStack>

            </FormWrapperStack>
        </StyledPaper>
    )
}

export default Login

//Styled
const StyledPaper = styled(Paper)({
    width: 500,
    height: "fit-content",
    padding: "2rem",
    boxSizing: "border-box"
})

const FormWrapperStack = styled(Stack)({
    width: "100%",
    display: "flex",
    justifyContent: "center",
    alignItems: "center"
})

const ComponentGroupStack = styled(Stack)({
    width: "100%",
    display: "flex",
    alignItems: "center",
    justifyContent: "center"
})