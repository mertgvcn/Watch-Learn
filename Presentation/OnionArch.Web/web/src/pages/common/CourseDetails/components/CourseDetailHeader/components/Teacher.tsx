//mui components
import { Stack, Typography } from '@mui/material'
//icons
import AccountCircleIcon from '@mui/icons-material/AccountCircle';

type TeacherType = {
    firstName: string,
    lastName: string
}

const Teacher = (props: TeacherType) => {
    return (
        <Stack direction="row" spacing={0.5} sx={{ alignItems: "center" }}>
            <AccountCircleIcon sx={{ fontSize: 26 }} />
            <Typography variant='subtitle1'>{props.firstName} {props.lastName}</Typography>
        </Stack>
    )
}

export default Teacher