import Icon from "@mdi/react";
import avatar from "../assets/avatar.jpg";
import { mdiMinus, mdiWindowMaximize, mdiClose } from "@mdi/js";

function Links() {
  interface Link {
    name: string;
    url?: string;
  }

  const links: Link[] = [
    {
      name: "Mon PC",
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
    <div className="xp-window p-2 mt-2 w-75">
      <div className="xp-title-bar d-flex justify-content-between align-items-center">
        <span>Mes Liens</span>
        <div>
          <button className="xp-title-button btn btn-sm p-0 mx-1">
            <Icon path={mdiMinus} size={0.6} />
          </button>
          <button className="xp-title-button btn btn-sm p-0 mx-1">
            <Icon path={mdiWindowMaximize} size={0.6} />
          </button>
          <button className="xp-title-button btn btn-sm p-0 mx-1 xp-close-button">
            <Icon path={mdiClose} size={0.6} />
          </button>
        </div>
      </div>
      <div className="p-3 text-center">
        <img src={avatar} alt="Avatar" className="xp-avatar mb-3" />
        <h2 className="h4">DownyDowner</h2>
      </div>
      <div className="d-flex flex-column justify-content-center align-items-center gap-2 px-3 pb-3">
        {links.map((link, index) => (
          <a
            key={index}
            href={link.url}
            target={link.url ? "_blank" : undefined}
            rel={link.url ? "noopener noreferrer" : undefined}
            className="xp-button w-50"
          >
            {link.name}
          </a>
        ))}
      </div>
    </div>
  );
}

export default Links;
