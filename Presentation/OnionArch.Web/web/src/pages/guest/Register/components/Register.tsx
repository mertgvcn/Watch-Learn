import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom'
//mui icons
import { Typography, TextField, Button, Paper, Stack, styled } from '@mui/material'
//icons
import AppRegistrationIcon from '@mui/icons-material/AppRegistration';
//models
import { UserRegisterRequest } from '../../../../models/paramaterModels/Authentication/UserRegisterRequest';
//helpers
import { Encrypt } from '../../../../utils/Cryption';
import AuthenticationAPI from '../../../../utils/APIs/AuthenticationAPI';
import toast from 'react-hot-toast';

type RegisterType = {
    firstName: string,
    lastName: string,
    email: string,
    phoneNumber: string,
    password: string
}

const Register = () => {
    const navigate = useNavigate()

    const [form, setForm] = useState<RegisterType>({
        firstName: "",
        lastName: "",
        email: "",
        phoneNumber: "",
        password: ""
    })
    const [buttonBlocker, setButtonBlocker] = useState(false)

    const handleChange = (e: any) => {
        const { name, value } = e.target

        setForm({
            ...form, [name]: value
        })
    }

    const handleRegister = async () => {
        setButtonBlocker(true)
        
        const userRegisterRequest: UserRegisterRequest = {
            firstName: form.firstName,
            lastName: form.lastName,
            email: form.email,
            phoneNumber: form.phoneNumber,
            encryptedPassword: await Encrypt(form.password)
        }

        const response = AuthenticationAPI.Register(userRegisterRequest)

        toast.promise(
            response,
            {
                loading: "Registration in progress...",
                success: "Registration successful.",
                error: null
            }
        )

        setTimeout(() => {
            navigate("/login")
        }, 1000)
    }

    return (
        <StyledPaper elevation={2}>
            <FormWrapperStack direction="column" spacing={4}>

                <ComponentGroupStack direction="column" spacing={1}>
                    <AppRegistrationIcon sx={{ fontSize: 32 }} />
                    <Typography variant='h5'>Sign Up</Typography>
                </ComponentGroupStack>

                <ComponentGroupStack direction="column" spacing={2}>
                    <TextField
                        name="firstName"
                        label="First name"
                        type='text'
                        size='small'
                        fullWidth
                        value={form.firstName}
                        onChange={handleChange}
                    />
                    <TextField
                        name="lastName"
                        label="Last name"
                        type='text'
                        size='small'
                        fullWidth
                        value={form.lastName}
                        onChange={handleChange}
                    />
                    <TextField
                        name="email"
                        label="Email"
                        type='email'
                        size='small'
                        fullWidth
                        value={form.email}
                        onChange={handleChange}
                    />
                    <TextField
                        name="phoneNumber"
                        label="Phone number"
                        type='text'
                        size='small'
                        fullWidth
                        value={form.phoneNumber}
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
                        onClick={handleRegister}
                    >
                        Sign Up
                    </Button>

                    <Link to="/login" style={{ textDecoration: "none" }}>
                        <Button size='small' >Already have an account? Sign in</Button>
                    </Link>
                </ComponentGroupStack>

            </FormWrapperStack>
        </StyledPaper>
    )
}

export default Register

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