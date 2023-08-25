import SidebarHeader from './components/header/Header';
import ConfiguredRouter from './routing/ConfiguredRouter';

export default function App() {
    return (
        <div className="w-100 mt-5 d-flex justify-content-center">
            <aside style={{ width: 200 }} className="me-5">
                <SidebarHeader />
            </aside>
            <main style={{ width: 500 }}>
                <ConfiguredRouter />
            </main>
        </div>
    );
}