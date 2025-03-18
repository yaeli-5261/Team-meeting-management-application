import { Container, Typography } from "@mui/material";

const HomePage = () => {
    return (
        <Container 
            maxWidth="lg" 
            sx={{ 
                display: 'flex', 
                flexDirection: 'column', 
                alignItems: 'center', 
                justifyContent: 'center', 
                height: '100vh', 
            }}
        >
            <Typography variant="h4" component="h1" gutterBottom>
                Upload Your Invoice
            </Typography>
        </Container>
    );
};

export default HomePage;
