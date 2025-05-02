import XpWindow from "../components/XpWindow";
import avatar from "../assets/avatar.jpg";
import { useState } from "react";
import PcModal from "./HomeLinksPcModal";

function Links() {
  const [isOpen, setIsOpen] = useState(false);

  const openModal = () => setIsOpen(true);
  const closeModal = () => setIsOpen(false);

  interface Link {
    name: string;
    url?: string;
    onClick?: () => void;
  }
  const links: Link[] = [
    {
      name: "Mon PC",
      onClick: openModal,
    },
    {
      name: "Instagram",
      url: "https://www.instagram.com/bobov__/",
    },
    {
      name: "Twitter",
      url: "https://x.com/DownyDowner",
    },
    {
      name: "Mangacollec",
      url: "https://www.mangacollec.com/user/bobov_/collection",
    },
    {
      name: "TikTok",
      url: "https://www.tiktok.com/@bobov__",
    },
    {
      name: "GitHub",
      url: "https://github.com/DownyDowner",
    },
    {
      name: "Speedrun.com",
      url: "https://www.speedrun.com/users/DownyDowner",
    },
    {
      name: "Youtube",
      url: "https://www.youtube.com/@downydowner",
    },
  ];

  return (
    <XpWindow title="Mes Liens">
      <div className="p-3 text-center">
        <img src={avatar} alt="Avatar" className="xp-avatar mb-3" />
        <h2 className="h4">DownyDowner</h2>
      </div>
      <div className="d-flex flex-column justify-content-center align-items-center gap-2 px-3 pb-3">
        <PcModal isOpen={isOpen} onClose={closeModal} />
        {links.map((link, index) => (
          <a
            key={index}
            href={link.url}
            target={link.url ? "_blank" : undefined}
            rel={link.url ? "noopener noreferrer" : undefined}
            className="xp-button w-50"
            onClick={link.onClick}
          >
            {link.name}
          </a>
        ))}
      </div>
    </XpWindow>
  );
}

export default Links;
