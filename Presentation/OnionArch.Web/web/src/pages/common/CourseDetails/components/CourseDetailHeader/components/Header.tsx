import { Stack, Typography } from '@mui/material'

type HeaderType = {
    title: string,
    shortDescription: string
}

const Header = ({ title, shortDescription }: HeaderType) => {
    return (
        <Stack direction="column" spacing={2}>
            <Typography variant='h3'>{title}</Typography>
            <Typography variant='body1'>{shortDescription}</Typography>
        </Stack>
    )
}

export default Header